$(document).ready(function () {

    // first example
    $("#tagTree").treeview({
        persist: "location",
        collapsed: true,
        unique: true
    });

    // third example
    $("#taxonomyTree2").treeview({
        animated: "fast",
        collapsed: true,
        unique: true,
        persist: "cookie",
        toggle: function () {
            window.console && console.log("%o was toggled", this);
        }
    });

    // fourth example
    $("#taxonomyTree3").treeview({
        control: "#treecontrol",
        persist: "cookie",
        cookieId: "treeview-black"
    });

});