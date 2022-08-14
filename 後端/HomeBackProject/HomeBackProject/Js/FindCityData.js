﻿
function mainIdex() {
    var selectCountyValue = $('#selectCounty').val();
    //console.log(selectCountyValue);
    var selecttwValue = $('#selectCity').children().text();
    //console.log(selecttwValue);

    var cityid = "";
    var cityadd = "";
    $('#selectCity').empty();
    if (selecttwValue == "請先選擇城市") {
        cityadd = `<option disabled style="display: none" selected value>請選擇</option>`;
    } else {
        cityadd = `<option disabled style="display: none"  value>${selecttwValue}</option>`;
    }
    $('#selectCity').append(cityadd);

    var arr = [];
    $.ajax({
        url: `https://api.nlsc.gov.tw/other/ListTown1/${selectCountyValue}`,
        type: 'GET',
        timeout: 1000,
        success: function (data) {
            //console.log(data)
            for (i = 0; i < $(data).find("townname").length; i++) {
                cityid = data.getElementsByTagName("townname")[i].firstChild.nodeValue;
                //console.log(cityid);

                arr = Array.from(cityid);
                //console.log(arr);
                //console.log(arr.indexOf("縣"));
                //console.log(arr.indexOf("市"));

                if (arr.indexOf("縣") == -1 && arr.indexOf("市") == -1) {
                    cityadd = `<option value="${cityid}">${cityid}</option>`;
                    $('#selectCity').append(cityadd);
                }
            }
        }
    });
}
