using System;
using System.Text;

public static class ClipboardFusionHelper
{
  public static string ProcessText(string text)
  {
    BFS.General.ThreadWait(2000);
    // BFS.General.ThreadWait(20);
    StringBuilder sendKeyString = new StringBuilder();
    bool isShiftDown = false;
    foreach(char c in text)
    {
      //smart shift syntax building for letters
      if(char.IsLetter(c) || c == ' ')
      {
        if(char.IsUpper(c) && isShiftDown)
        {
          sendKeyString.Append(c);
          continue;
        }

        if(char.IsUpper(c) && !isShiftDown)
        {
          isShiftDown = true;
          sendKeyString.Append("+(").Append(c);
          continue;
        }

        if(char.IsLower(c) && isShiftDown)
        {
          isShiftDown = false;
          sendKeyString.Append(')').Append(char.ToUpperInvariant(c));
          continue;
        }

        if(char.IsLower(c) && !isShiftDown)
        {
          sendKeyString.Append(char.ToUpperInvariant(c));
          continue;
        }
      }

      if(char.IsDigit(c))
      {
        if(isShiftDown)
        {
          isShiftDown = false;
          sendKeyString.Append(')').Append(c);
          continue;
        }

        sendKeyString.Append(c);
        continue;
      }

      //turn off smart shift here
      if(isShiftDown)
      {
        isShiftDown = false;
        sendKeyString.Append(')');
      }

      //this part will only work with en-us keyboards
      switch(c)
      {
        case '~':
          sendKeyString.Append("+(`)");
          break;
        case '!':
          sendKeyString.Append("+(1)");
          break;
        case '@':
          sendKeyString.Append("+(2)");
          break;
        case '#':
          sendKeyString.Append("+(3)");
          break;
        case '$':
          sendKeyString.Append("+(4)");
          break;
        case '%':
          sendKeyString.Append("+(5)");
          break;
        case '^':
          sendKeyString.Append("+(6)");
          break;
        case '&':
          sendKeyString.Append("+(7)");
          break;
        case '*':
          sendKeyString.Append("+(8)");
          break;
        case '(':
          sendKeyString.Append("+(9)");
          break;
        case ')':
          sendKeyString.Append("+(0)");
          break;
        case '_':
          sendKeyString.Append("+(-)");
          break;
        case '+':
          sendKeyString.Append("+(=)");
          break;
        case '{':
          sendKeyString.Append("+([)");
          break;
        case '}':
          sendKeyString.Append("+(])");
          break;
        case '|':
          sendKeyString.Append("+(\\)");
          break;
        case ':':
          sendKeyString.Append("+(;)");
          break;
        case '"':
          sendKeyString.Append("+(')");
          break;
        case '<':
          sendKeyString.Append("+(,)");
          break;
        case '>':
          sendKeyString.Append("+(.)");
          break;
        case '?':
          sendKeyString.Append("+(/)");
          break;
        default:
          sendKeyString.Append(c);
          break;
      }
    }

    // BFS.Input.SendKeys(sendKeyString.ToString());                 //Regular
    // BFS.Input.SendKeysFast(sendKeyString.ToString());             //Light Speed
    BFS.Input.SendKeysFastWithoutWait(sendKeyString.ToString());     //Ludicrous Speed "They've gone to plaid!"
    return text;
  }
}
