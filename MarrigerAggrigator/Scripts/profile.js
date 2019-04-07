
function GetProfiles() {
    var search_metdaData = {};
    $.ajax({
        async: false,
        type: "POST",
        url: "Matrimony/GetSearchMetaData",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var result = data;
            console.log(result);
            search_metdaData = new SearchMetaData(result.MotherTounge, result.Religion, result.Community, result.SpecialCategory);
        },
        error: function () {
            alert("Error occured!!")
        }
    })

    FillSearchMetaData(search_metdaData.religion,"#religion");
    FillSearchMetaData(search_metdaData.motherTounge, "#mothertounge");
    FillSearchMetaData(search_metdaData.community, "#community");
    FillSearchMetaData(search_metdaData.specialCategory, "#specialCategory");


}


function FillSearchMetaData(religion,id) {
    var religion = religion;
    var religionSelect = $(id);

    religion.forEach(function (item) {
        var opt = document.createElement('option');
        opt.innerHTML = item;
        opt.value = item;
        religionSelect.append(opt);
    });
}





