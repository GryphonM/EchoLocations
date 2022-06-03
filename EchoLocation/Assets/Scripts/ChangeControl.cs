//------------------------------------------------------------------------------
//
// File Name:	ChangeControl.cs
// Author(s):	Gryphon McLaughlin (gryphon.mclaughlin)
// Project:	GAM 5.1.3 CHALLENGE: Platformer
// Course:	WANIC VGP2
//
// Copyright © 2019 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeControl : MonoBehaviour
{
    public static string ConvertToString(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.Keypad0:
            case KeyCode.Alpha0:
                return "0";
            case KeyCode.Keypad1:
            case KeyCode.Alpha1:
                return "1";
            case KeyCode.Keypad2:
            case KeyCode.Alpha2:
                return "2";
            case KeyCode.Keypad3:
            case KeyCode.Alpha3:
                return "3";
            case KeyCode.Keypad4:
            case KeyCode.Alpha4:
                return "4";
            case KeyCode.Keypad5:
            case KeyCode.Alpha5:
                return "5";
            case KeyCode.Keypad6:
            case KeyCode.Alpha6:
                return "6";
            case KeyCode.Keypad7:
            case KeyCode.Alpha7:
                return "7";
            case KeyCode.Keypad8:
            case KeyCode.Alpha8:
                return "8";
            case KeyCode.Keypad9:
            case KeyCode.Alpha9:
                return "9";
            case KeyCode.KeypadPeriod:
            case KeyCode.Period:
                return ".";
            case KeyCode.KeypadDivide:
            case KeyCode.Slash:
                return "/";
            case KeyCode.KeypadMultiply:
            case KeyCode.Asterisk:
                return "*";
            case KeyCode.KeypadMinus:
            case KeyCode.Minus:
                return "-";
            case KeyCode.KeypadPlus:
            case KeyCode.Plus:
                return "+";
            case KeyCode.KeypadEnter:
                return "Return";
            case KeyCode.KeypadEquals:
            case KeyCode.Equals:
                return "=";
            case KeyCode.UpArrow:
                return "Up Arrow";
            case KeyCode.DownArrow:
                return "Down Arrow";
            case KeyCode.RightArrow:
                return "Right Arrow";
            case KeyCode.LeftArrow:
                return "Left Arrow";
            case KeyCode.PageUp:
                return "Page Up";
            case KeyCode.PageDown:
                return "Page Down";
            case KeyCode.Exclaim:
                return "!";
            case KeyCode.DoubleQuote:
                return "\"";
            case KeyCode.Hash:
                return "#";
            case KeyCode.Dollar:
                return "$";
            case KeyCode.Percent:
                return "%";
            case KeyCode.Ampersand:
                return "&";
            case KeyCode.Quote:
                return "'";
            case KeyCode.LeftParen:
                return "(";
            case KeyCode.RightParen:
                return ")";
            case KeyCode.Comma:
                return ",";
            case KeyCode.Colon:
                return ":";
            case KeyCode.Semicolon:
                return ";";
            case KeyCode.Less:
                return "<";
            case KeyCode.Greater:
                return ">";
            case KeyCode.Question:
                return "?";
            case KeyCode.At:
                return "@";
            case KeyCode.LeftBracket:
                return "[";
            case KeyCode.Backslash:
                return "\\";
            case KeyCode.RightBracket:
                return "]";
            case KeyCode.Caret:
                return "^";
            case KeyCode.Underscore:
                return "_";
            case KeyCode.BackQuote:
                return "`";
            case KeyCode.LeftCurlyBracket:
                return "{";
            case KeyCode.Pipe:
                return "|";
            case KeyCode.RightCurlyBracket:
                return "}";
            case KeyCode.Tilde:
                return "~";
            case KeyCode.RightShift:
                return "Right Shift";
            case KeyCode.LeftShift:
                return "Left Shift";
            case KeyCode.RightControl:
                return "Right Control";
            case KeyCode.LeftControl:
                return "Left Control";
            case KeyCode.RightAlt:
                return "Right Alt";
            case KeyCode.LeftAlt:
                return "Left Alt";
            case KeyCode.LeftCommand:
                return "Left Command";
            case KeyCode.RightCommand:
                return "Right Command";
            case KeyCode.Mouse0:
                return "Left Mouse Button";
            case KeyCode.Mouse1:
                return "Right Mouse button";
            case KeyCode.Mouse2:
                return "Middle Mouse Button";
            default:
                return key.ToString();
        }
    }
}
