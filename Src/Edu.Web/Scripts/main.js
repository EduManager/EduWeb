var widgetToggle = function () {
    $(".actions > .glyphicon-chevron-up").click(function () {
        $(this).parent().parent().next().slideToggle("fast"), $(this).toggleClass("glyphicon-chevron-up glyphicon-chevron-down")
    });
};