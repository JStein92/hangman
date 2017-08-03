using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HangmanGame.Models;

namespace HangmanGame.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      Hangman newHangman = new Hangman();
      return View();
    }
    [HttpGet("/NewGuess")]
    public ActionResult NewGuess()
    {
      return View();
    }

    [HttpPost("/")]
    public ActionResult Guess()
    {
      char newGuess = Char.Parse(Request.Form["guess"]); //get user character guess
      Hangman newHangman = new Hangman();

      return View("Index", newHangman.Match(newGuess));
    }
  }
}
