onChangeTab = (id) => {
    $("#HomePageButton").css("background", "white");
    $("#ProductsButton").css("background", "white");
    $("#AboutButton").css("background", "white");

    $("#" + id).css("background", "#D2D2D2");
}