function Category(id, name) {
    var _this = this;
    _this.Id = id;
    _this.Name = name;
    _this._SubCategories = undefined;

    _this.getSubCategories = function () {
        if (_this._SubCategories) {
            return _this._SubCategories;
        }

        _this._SubCategories = ko.utils.arrayFilter(categoryList, function (category) {
            return category.ParentId == _this.Id;
        }).map(function (category) {
            return new Category(category.Id, category.Name);
        });

        return _this._SubCategories;
    };
};

function Location(id, name) {
    this.Id = id;
    this.Name = name;
};

function City(id, name) {
    this.Id = id;
    this.Name = name;
    var _this = this;
    this.Locations = ko.utils.arrayFilter(locationList, function (location) {
        return location.CityId == _this.Id;
    }).map(function (location) {
        return new Location(location.Id, location.Name, location)
    });
};



function PostAnAdVM() {

    var _this = this;
    _this.SelectedLevelOneCategory = ko.observable();
    _this.SelectedLevelTwoCategory = ko.observable();
    _this.SelectedLevelThreeCategory = ko.observable();
    _this.SelectedCity = ko.observable();
    _this.SelectedLocation = ko.observable();
    _this.AgreedTerms = ko.observable(false);

    _this.FirstLevelCategories = ko.utils.arrayFilter(categoryList, function (category) {
        return !category.ParentId;
    }).map(function (category) {
        return new Category(category.Id, category.Name);
    });

    _this.SelectedLevelOneCategory.subscribe(function () {
        _this.SelectedLevelTwoCategory(undefined);
    });
    _this.SelectedLevelTwoCategory.subscribe(function () {
        _this.SelectedLevelThreeCategory(undefined);
    });

    _this.imageUpload = function (data, e) {
        var file = e.target.files[0];
        var reader = new FileReader();

        reader.onloadend = function (loadEvent) {
            var result = reader.result;
            var index = _this.AdImages().length;
            var imageId = "#image-" + index;
            $(imageId).attr("src", result).show();
        }

        if (file && file.size <= 500000) {
            reader.readAsDataURL(file);
            $("#large-img-msg").hide();
        } else {
            if (file) {
                $("#large-img-msg").show();
            }
            _this.AdImages.pop();
        }
    };

    _this.AdImages = ko.observableArray();
    _this.selectImage = function (data, event) {
        event.preventDefault();
        _this.AdImages.push(ko.observable());
        var inputFileId = "#ad-image-" + _this.AdImages().length;
        $(inputFileId).trigger("click");
    };
    _this.deleteImage = function (data, event) {
        var element = event.target;
        var index = $(element).data('index') - 1;
        _this.AdImages.splice(index, 1);
    };

    _this.removeEmptyFileInputs = function (data, event) {
        event.preventDefault();
        for (var i = 0; i < _this.AdImages().length; i++) {
            var input = $("#ad-image-" + (i + 1))[0];
            if (!input.files || !input.files.length) {
                _this.AdImages.splice(i, 1);
            }
        }
        $("#post-ad-form").submit();
    }

    _this.Cities = ko.utils.arrayMap(cityList, function (city) {
        return new City(city.Id, city.Name);
    });

}

var PostAnAd = {
    init: function () {
        ko.applyBindings(new PostAnAdVM());
    },

};