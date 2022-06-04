function sendVote(postId, isUpVote) {
    var token = $("#votesForm input[name=__RequestVerificationToken]").val();
    var json = { postId: postId, isUpVote: isUpVote };
    $.ajax({
        type: "POST",
        url: "/api/votes",
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: { 'X-CSRF-TOKEN': token },
        success: function (data) {
            $("#votesCount").html(data.votesCount);
        }
    });
}

function addFavorite(postId, userId) {
    var token = $("#favoriteForm input[name=__RequestVerificationToken]").val();
    var json = { postId: postId, userId: userId };
    $.ajax({
        type: "POST",
        url: "/api/favorites",
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: { 'X-CSRF-TOKEN': token },
        success: document.getElementById('heart').style.color = 'red',
    });
}
