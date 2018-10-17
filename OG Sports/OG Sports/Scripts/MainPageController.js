onChangeTab = (id) => {
    $("#HomePageButton").css("background", "transparent");
    $("#ProductsButton").css("background", "transparent");
    $("#AboutButton").css("background", "transparent");

    $("#" + id).css("background", "#007bff").css("color", "white");

}