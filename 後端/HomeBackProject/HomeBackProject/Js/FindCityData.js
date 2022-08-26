
function mainIdex() {
    var selectCountyValue = $('#selectCounty').val();
    console.log(selectCountyValue);
    //var selecttwValue = $('#selectCity').children().text();
    var selecttwValue = $('#selectCity').children().val();
    console.log(selecttwValue);
    
    var cityid = "";
    var cityadd = "";
    $('#selectCity').empty();
    if (selecttwValue == "不拘") {
        cityadd = `<option value>不拘</option>`;
    } else if (selecttwValue == "") {
        cityadd = `<option value>不拘</option>`;
    } else if (selecttwValue == "請先選擇城市") {
        cityadd = `<option disabled style="display: none" selected value="請先選擇城市">請選擇</option>`;
    }else {
        cityadd = `<option  value="${selecttwValue}">${selecttwValue}</option>`;
    }
    $('#selectCity').append(cityadd);

    //下面這個判斷使用在search用的
    if (selecttwValue == "不拘請先選擇縣市") {
        cityadd = `<option selected value>不拘</option>`;
        $('#selectCity').append(cityadd);
    }
    var arr = [];
    $.ajax({
        url: `https://api.nlsc.gov.tw/other/ListTown/${selectCountyValue}`,
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
                console.log(selecttwValue);

                if (arr.indexOf("縣") == -1 && arr.indexOf("市") == -1) {
                    cityadd = `<option value="${cityid}">${cityid}</option>`;
                    $('#selectCity').append(cityadd);
                }
            }
        }
    });
}
