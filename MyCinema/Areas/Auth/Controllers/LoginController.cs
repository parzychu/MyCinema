﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MyCinema.Areas.Auth.Models;
using MyCinema.Areas.Auth.Services;
using Newtonsoft.Json.Serialization;
using AuthorizeAttribute = System.Web.Mvc.AuthorizeAttribute;

namespace MyCinema.Areas.Auth.Controllers
{
    public class LoginController : Controller
    {
        private AuthRepository _repo = null;

        public LoginController()
        {
            _repo = new AuthRepository();
        }

        // POST api/Account/Register
        [System.Web.Http.AllowAnonymous]
        public async Task<ActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityResult result = await _repo.RegisterUser(userModel);

            ActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return new HttpStatusCodeResult(200);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private ActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                return Json(result);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return null;
        }
    }
}