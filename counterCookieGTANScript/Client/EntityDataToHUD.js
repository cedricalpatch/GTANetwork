API.onUpdate.connect(function () {

    if (!API.getHudVisible()) {
        return;
    }

    if (API.hasEntitySyncedData(API.getLocalPlayer(), "MONEY")) {

        var money = API.getEntitySyncedData(API.getLocalPlayer(), "MONEY");

        var resX = API.getScreenResolutionMantainRatio().Width;

        API.drawText("~g~Your money: ~w~" + money, resX - 30, 150, 0.5, 83, 119, 237, 255, 4, 2, false, true, 0);
    }

});