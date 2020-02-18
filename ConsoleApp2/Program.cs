using Attachmate.Reflection.Emulation.IbmHosts;
using Attachmate.Reflection.Emulation.OpenSystems;
using Attachmate.Reflection.Framework;
using Attachmate.Reflection.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get a handle to an application that represents the first instance of Reflection started manually.
            //For production code, use a try catch block here to handle a System Application Exception thrown
            //if the app isn't running.
            Application app = MyReflection.CreateApplication();

            //Get the frame and the selected view
            IFrame frame = (IFrame)app.GetObject("Frame");
            IView view = frame.SelectedView;

            //If the IBM view is selected, get some text from its screen
            if (view.TitleText == "mySession.rd3x")
            {
                IIbmTerminal terminalIBM = (IIbmTerminal)view.Control;
                IIbmScreen screenIBM = terminalIBM.Screen;
                Console.WriteLine(screenIBM.GetTextEx(1, 1, screenIBM.Rows, screenIBM.Columns, GetTextArea.Block, GetTextWrap.Off, GetTextAttr.Any, GetTextFlags.None));
            }
            //If the Open Systems view is selected, get some text from its screen
            if (view.TitleText == "mySession.rdox")
            {
                ITerminal terminalOS = (ITerminal)view.Control;
                IScreen screenOS = terminalOS.Screen;
                Console.WriteLine(screenOS.GetText(1, 1, screenOS.DisplayRows, screenOS.DisplayColumns));
            }
        }
    }
}
