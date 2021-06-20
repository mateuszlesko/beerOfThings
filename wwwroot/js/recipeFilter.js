function RecipeFiltring() {

    let selectedRecipe = document.getElementById("categoryPicker");
    let category = selectedRecipe.options[selectedRecipe.selectedIndex].value;
    console.log("XD" + category)
    let form = document.getElementById("fitringRecipes");
    if (form) {
        form.action = "/Recipe/" + "?category=" + category;
        form.submit();
    }

}