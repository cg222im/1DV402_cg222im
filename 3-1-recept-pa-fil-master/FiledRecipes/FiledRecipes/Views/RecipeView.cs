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
            Header = recipe.Name;
            ShowHeaderPanel();

            //skriva ut ingredients
            //skriva ut instructions


            //foreach (Recipe ingredient in recipe.Ingredients)
            //{
            //    Console.WriteLine(recipe.Ingredients);

            //}

            //Console.WriteLine(recipe.Ingredients);
            //Console.WriteLine(recipe.Instructions);

            //Panel = recipe.Ingredients;
            //ShowPanel();
            
            //skriva ut i rätt format, hur skriva ut innehåll objekt?
            
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
