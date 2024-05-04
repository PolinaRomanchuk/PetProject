

function myProfileInfo() {
    return (
        <div>
            <div class="header-profile-container">
                <div class="avatar">
                    <img class="avatar" src="@Model.PhotoUrl"/>
                </div>

                <div class="header-profile-main-info">
                    <div class="name-info">
                        <div>
                            @authService.GetUser().LoginName
                        </div>
                        <div>
                            <a class="pencil-logo" href="UpdateProfile/@Model.Id"> <img src="~/images/pencil.png" class="pencil-logo" /></a>
                        </div>
                        <div>
                            <a class="add-new-post-logo" href="UpdateProfile/@Model.Id"> <img src="~/images/addnewpost.png" class="add-new-post-logo" /></a>
                        </div>
                    </div>

                    <div class="profile-info">
                        <div class="profile-info-item">
                            @Model.PostsCount публикаций
                        </div>
                        <div class="profile-info-item">
                            @Model.FollowingCount подписок
                        </div>
                        <div class="profile-info-item">
                            @Model.FollowersCount подписчиков
                        </div>
                    </div>

                    <div class="pet-name-info">
                        <div>
                            @Model.PetName
                        </div>
                    </div>
                    <div class="info-bio">
                        <div>
                            @Model.InfoBio
                        </div>
                    </div>

                </div>
            </div>
        </div>
    );
};
export default myProfileInfo;