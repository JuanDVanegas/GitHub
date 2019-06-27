var GigDetailsController = function (followingService) {

    var button;

    var init = function() {
        $(".js-toggle-follow").click(toggleFollowing);        
    };

    var toggleFollowing = function (e) {
        button = $(e.target);

        var followeeId = button.attr("data-user-id");

        if (button.hasClass("btn-default"))
            followingService.follow(followeeId, done, fail);
        else
            followingService.unFollow(followeeId, done, fail);
    };

    var done = function () {
        var text = (button.text() === "Seguir") ? "Siguiendo" : "Seguir";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    var fail = function () {
        alert("Algo salio mal!");
    };

    return {
        init: init
    }
    
}(FollowingService);