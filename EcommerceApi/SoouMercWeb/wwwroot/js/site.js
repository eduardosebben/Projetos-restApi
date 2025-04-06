$(document).ready(function () {
    $("#sidebarCollapse").on("click", function () {
        $("#sidebar").toggleClass("active");
        $(this).toggleClass("active");
    });

    $(".submenu").click(function () {
        $(this).toggleClass("active");
    });
});