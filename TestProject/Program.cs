using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoForms;
using MonoForms.Collections;
using MonoForms.ControlDecoretors;

namespace TestProject
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            /*var traditionalForm = new TestForm1();
            traditionalForm.Show();
            using (var monoForm = new MonoForms.WinFormsAdapter(traditionalForm))
            {
                monoForm.Show();
            }*/

            using (var monoForm = new MonoForms.SimpleForm())
            {
                var helloButton = new Button("hello world");
                helloButton.Rectangle = new Rectangle(20, 30, 50, 200);

                helloButton.MouseEnter += (sender, e) => helloButton.Position += new Vector2(rnd.Next(-1, 2), rnd.Next(-1, 2));



                IControl helloLabel = new Label()
                {Position = new Vector2(100,100),Text="hello world"};
                helloLabel = new ControlVisibleForNTime(helloLabel, 4.0f);

                monoForm.Controls = new Node<IControl>(helloButton,monoForm.Controls);
                monoForm.Controls = new Node<IControl>(helloLabel, monoForm.Controls);

                monoForm.Show();
            }
            
        }
    }
}
