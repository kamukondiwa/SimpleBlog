$(document).ready(function () {
    preselectAssignedTags();
    tagsClickHandler();
    printDefaultMessage();
    tagsModalBoxClickHandler();
});

function preselectAssignedTags() {
    $('div#assigned-tags-container input:hidden').each(function () {
        var checboxName = $(this).val();
        $('#tagTree input:checkbox').each(function () {
            if (this.name.length > 0 && this.name == checboxName) {
                var checked = $(this).attr('checked', true);
                updateSeletedItems(this);
            }
        });
    });
};

function tagsClickHandler() {
    $('#tags input:checkbox').live('click', function () {
        clearDefaultMessage();
        updateSeletedItems(this);
    });
};

function updateSeletedItems(checkbox) {
    var checked = $(checkbox).attr('checked');
    var tagId = checkbox.name.substr(checkbox.name.indexOf('-') + 1, name.length + 1);

    if (checked) {
        var elementExists = $('#container-' + tagId + '').exists();
        if (!elementExists) {
            $('#selected-tags').append('<div id=\'container-' + tagId + '\'>');
            $('#selected-tags #container-' + tagId + '').append('<p id=\'' + checkbox.name + '-title\' class=\'selected-tag tag-message\'>' + checkbox.name.substr(0, checkbox.name.indexOf('-')) + '</p>');
            $('#selected-tags #container-' + tagId + '').append('<input type=\'hidden\' id=\'form_Tags\' name=\'form.Tags\' value=\'' + checkbox.name + '\'/>');
            $('#selected-tags').append('</div>');
        }
    } else {
        $('#selected-tags').children().remove('#container-' + tagId + '');
        printDefaultMessage();
    }
};

function printDefaultMessage() {
    if (!$('#selected-tags').children().exists()) {
        $('#selected-tags').append('<p class=\'selected-tag tag-message\'>No Tags Selected.</p>');
    }
};

function clearDefaultMessage() {
    if ($('#selected-tags').children().length == 1) {
        if ($('#selected-tags p').text() == 'No Tags Selected.') {
            $('#selected-tags').children().remove();
        }
    }
};

function tagsModalBoxClickHandler() {
    //select all the a tag with name equal to modal
    $('a[name=modal]').click(function (e) {
        //Cancel the link behavior
        e.preventDefault();
        //Get the A tag
        var id = $(this).attr('href');

        //Get the screen height and width
        var maskHeight = $(document).height();
        var maskWidth = $(window).width();

        //Set height and width to mask to fill up the whole screen
        $('#mask').css({ 'width': maskWidth, 'height': maskHeight });

        //transition effect		
        $('#mask').fadeIn(1000);
        $('#mask').fadeTo("slow", 0.8);

        //Get the window height and width
        var winH = $(window).height();
        var winW = $(window).width();

        //Set the popup window to center
        $(id).css('top', winH / 2 - $(id).height() / 2);
        $(id).css('left', winW / 2 - $(id).width() / 2);

        //transition effect
        $(id).fadeIn(2000);

    });

    //if close button is clicked
    $('.window .close').click(function (e) {
        //Cancel the link behavior
        e.preventDefault();
        $('#mask, .window').hide();
    });

    //if mask is clicked
    $('#mask').click(function () {
        $(this).hide();
        $('.window').hide();
    });

};

jQuery.fn.exists = function () { return jQuery(this).size() > 0; }