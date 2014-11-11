using FiledRecipes.Domain;
using FiledRecipes.App.Mvp;
using FiledRecipes.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FiledRecipes.Views
{
    /// <summary>
    /// 
    /// </summary>
    public class RecipeView : ViewBase, IRecipeView
    {
        public void Show(IRecipe recipe)
        {
            int instructionNumber = 1;
            Console.Clear();

            Header = recipe.Name;
            ShowHeaderPanel();

            Console.WriteLine("\nIngredienser");
            Console.WriteLine("=============");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine(ingredient);
            }

            Console.WriteLine("\nInstruktioner");
            Console.WriteLine("=============");
            foreach (var instruction in recipe.Instructions)
            {
                Console.WriteLine("<{0}>", instructionNumber);
                instructionNumber++;
                Console.WriteLine(instruction);
            }
        }

        public void Show(IEnumerable<IRecipe> recipes)
        {
            foreach (Recipe recipe in recipes)
            {
                Show(recipe);
                ContinueOnKeyPressed();
            }
        }
    }
}
