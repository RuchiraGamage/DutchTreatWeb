﻿using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    public class AppController :Controller
    {
        private readonly IMailService _mailService;
        private readonly IDutchRepository _repository;

        public AppController(IMailService mailService, IDutchRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var result = _repository.GetAllProducts();
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //send the email
                _mailService.SendMessage("htruchira@gmail.com", model.Subject, $"From :{model.Name}-{model.Email}, Message :{model.Message}");
                ViewBag.UserMessage = "Mail send";
                ModelState.Clear();
            }
            else
            {

            }
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Shop()
        {
            var result = _repository.GetAllProducts();

            //same thing can be done using linq queries

            /*
               var result = from p in _context.Products
                            orderby p.Category
                            select p; 

            return View(result.ToList());
            */

            return View(result);
        }
    }
}
