using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Connect.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Server;
using Server.Models;


namespace Connect.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        private readonly MasterContext _context;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            _context = new MasterContext();
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users.OrderBy(u => u.Nome).ToList();
            return View(users);
        }

        [HttpGet]
        [Authorize(Roles = "Admin Geral")]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles.OrderBy(r => r.Name).ToList();
            return View(roles);
        }


        [HttpGet]
        [Authorize(Roles = "Admin Geral")]
        public IActionResult CreateRole()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin Geral")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                // We just need to specify a unique role name to create a new role
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                // Saves the role in the underlying AspNetRoles table
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Admin");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        // Role ID is passed from the URL to the action
        [HttpGet]
        [Authorize(Roles = "Admin Geral")]
        public async Task<IActionResult> EditRole(string id)
        {
            // Find the role by Role ID
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Perfil com Id = {id} não foi encontrado.";
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            // Retrieve all the Users
            foreach (var user in userManager.Users.ToList())
            {
                // If the user is in this role, add the username to
                // Users property of EditRoleViewModel. This model
                // object is then passed to the view for display
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        // This action responds to HttpPost and receives EditRoleViewModel
        [HttpPost]
        [Authorize(Roles = "Admin Geral")]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Perfil com Id = {model.Id} não foi encontrado.";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;

                // Update the Role using UpdateAsync
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Perfil com Id = {roleId} não foi encontrado.";
                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users.ToList())
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Perfil com Id = {roleId} não foi encontrado.";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        [HttpGet]
        public async Task<IActionResult> EditClientesInUser(string UserId)
        {
            ViewBag.userId = UserId;

            var user = await userManager.FindByIdAsync(UserId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usuário com Id = {UserId} não foi encontrado.";
                return View("NotFound");
            }

            var model = new List<UserClienteViewModel>();

            foreach (var cliente in _context.Clientes.Include(u=>u.UsersCliente).ToList())
            {
                var userClienteViewModel = new UserClienteViewModel
                {
                    ClienteId = cliente.Id,
                    Nome = cliente.Nome
                    
                   
                };

                if (cliente.UsersCliente.Any(e => e.UserId == user.Id))
                {
                    userClienteViewModel.IsSelected = true;
                }
                else
                {
                    userClienteViewModel.IsSelected = false;
                }

                model.Add(userClienteViewModel);
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditClientesInUser(List<UserClienteViewModel> model, string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usuário com Id = {userId} não foi encontrado.";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var cliente = await _context.Clientes.Include(u=>u.UsersCliente).FirstOrDefaultAsync(c=>c.Id == model[i].ClienteId);

                int result;

                if (model[i].IsSelected && !(cliente.UsersCliente.Any(e => e.UserId == user.Id)))
                {
                    UserCliente userCliente = new UserCliente();
                    userCliente.ClienteId = cliente.Id;
                    userCliente.UserId = user.Id;

                    user.UserClientes.Add(userCliente);
                    _context.UserClientes.Add(userCliente);
                                        
                    result = await _context.SaveChangesAsync();                  

                    
                }
                else if (!model[i].IsSelected && cliente.UsersCliente.Any(e => e.UserId == user.Id))
                {
                    var userCliente = _context.UserClientes.Find(user.Id,cliente.Id);
                    _context.UserClientes.Remove(userCliente);
                    result = await _context.SaveChangesAsync();
                }
                else
                {
                    continue;
                }

                if (result>0)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditUser", new { Id = userId });
                }
            }

            return RedirectToAction("EditUser", new { Id = userId });
        }


        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usuário com Id = {id} não foi encontrado.";
                return View("NotFound");
            }

            // GetClaimsAsync retunrs the list of user Claims
            var userClaims = await userManager.GetClaimsAsync(user);
            // GetRolesAsync returns the list of user Roles
            var userRoles = await userManager.GetRolesAsync(user);
            
            var model = new EditUserViewModel
            {
                Id = user.Id,
                Nome = user.Nome,
                UserName = user.UserName,                
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles
                
            };


            var clientes =  _context.UserClientes
                .Include(c => c.Cliente)
                .Where(u=>u.UserId == user.Id)
                .ToList();

            foreach (var cliente in clientes)
            {
                model.Clientes.Add(cliente.Cliente.Nome);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usuário com Id = {id} não foi encontrado.";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListUsers");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Nome = model.Nome;
                user.UserName = model.UserName;
                
                //user.UserClientes = model.Clientes;

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
