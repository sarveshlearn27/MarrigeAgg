//Search
$(document).ready(function () {
    GetProfiles();
    $('#search').click(function () {
        search();
    })
});


function search() {
    var search_metdaData = {};
    search_metdaData = new SearchMetaData($('#mothertounge').val(), $('#religion').val(), $('#community').val(), $('#specialCategory').val(), $('#sex').val());
    let AllWebSites = [];
    var isSuccess = false;

    $.ajax({
        async: false,
        type: "POST",
        url: "Matrimony/SearchPorfiles",
        data: JSON.stringify(search_metdaData),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            window.location.href = data.redirectTo;
            isSuccess = true;
        },
        error: function () {
            alert("Error occured!!")
        }
    });

    console.log(AllWebSites);
}
