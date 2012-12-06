$(document).ready(function() {
    $('.date-picker').datepicker({ dateFormat: 'dd MM yy' });
});

$(document).ready(function() {
    accordianmenu('.accordian-menu');
});

$(document).ready(function() {
    $('div.page-content').corner("15px");
});

$(document).ready(function () {
    $('div.rounded').corner("12px");
});

$(document).ready(function() {
   $(".lavaLamp").lavaLamp({ fx: "backout", speed: 800 });
});

$(document).ready(function() {
   $(".scrolling-feed").jCarouselLite({
        vertical: true,
        hoverPause: true,
        visible: 4,
        auto: 500,
        speed: 3000
    });
});