function accordianmenu(selector) {
    $(selector + ' ul').hide();
    $.each($(selector), function() {
        $('#' + this.id + '.expandfirst ul:first').show();
    });
    $(selector + ' li a').hover(function() {
    var checkElement = $(this).next();
    var parent = this.parentNode.parentNode.id;
    if ($('#' + parent).hasClass('noaccordion')) {
        $(this).next().slideToggle('slow');
        return false;
    }
    if ((checkElement.is('ul')) && (checkElement.is(':visible'))) {
        if ($('#' + parent).hasClass('collapsible')) {
            $('#' + parent + ' ul:visible').slideUp('normal');
        }
        return false;
    }
    if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
        $('#' + parent + ' ul:visible').slideUp('slow');
        checkElement.slideDown('slow');
        return false;
    }
}
);
}
