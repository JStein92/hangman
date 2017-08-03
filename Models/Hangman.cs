using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanGame.Models
{
  class Hangman
  {

    private static List<string> _words = new List<string>() {"CANDY", "HALLOWEEN" };
    private static string _word;
    private int _maxGuesses = 6;
    private static int _currentGuesses = 0;
    private int charPosition;
    private static int _correctGuesses;
    private static List<char> _guessedChars = new List<char>();

    private static string _blankString;

    public Hangman()
    {
      int randomNumber;
      Random RNG = new Random();
      randomNumber = RNG.Next(0,_words.Count);

      if (_blankString == null && _word == null)
      {
        _word = _words[randomNumber];
        foreach(char ch in _word)
        {
         _blankString += "*";
        }
      }
    }

    public Dictionary<string, object> Match(char charGuessed)
    {
      bool hadCorrectGuess = false;
      StringBuilder _blankStringBuilder = new StringBuilder(_blankString);

      charPosition=0;
      foreach(char _char in _word)
      {
        if (_char == charGuessed)
        {

          hadCorrectGuess=true;
          _correctGuesses ++;
          _blankStringBuilder[charPosition] = charGuessed;
          _blankString = _blankStringBuilder.ToString();
          Console.WriteLine(charGuessed + " is at position " + charPosition);
        }
          charPosition++;
      }
      if(hadCorrectGuess==false)
      {
            _currentGuesses++;
            _guessedChars.Add(charGuessed);
      }

      Dictionary<string, object> myDictionary = new Dictionary<string,object>();
      myDictionary.Add("blankstring", _blankString);
      myDictionary.Add("currentGuesses", _currentGuesses);
      myDictionary.Add("correctGuesses", _correctGuesses);
      myDictionary.Add("maxGuesses", _maxGuesses);
      myDictionary.Add("guessedChars", _guessedChars);

      return (myDictionary);
    }
  }
}
