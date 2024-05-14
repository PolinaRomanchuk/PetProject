import '../../css/profile.css'
import { profileApi } from '../../services/myProfileInfoApi'
import { useState, useEffect } from 'react';
import { AuthContext } from '../login/auth';
import { useContext } from 'react';
import pencil from '../../images/pencil.png'
import addnewpost from '../../images/addnewpost.png'

function MyProfileInfo() {
    const [profile, setProfile] = useState('');
    const { GetUserProfile } = profileApi;
    const { userId, name } = useContext(AuthContext);

    useEffect(function () {
        GetUserProfile(userId)
            .then(response => {
                console.log(response.data)
                setProfile(response.data)
            });
    }, [])

    return (
        <div>
            <div className="header-profile-container">
                <div className="avatar">
                    <img className="avatar" src={profile.photoUrl} />
                </div>

                <div className="header-profile-main-info">
                    <div className="name-info">
                        <div>
                            {name}
                        </div>
                        <div>
                            <a className="pencil-logo" > <img src={pencil} className="pencil-logo" /></a>
                        </div>
                        <div>
                            <a className="add-new-post-logo" > <img src={addnewpost} className="add-new-post-logo" /></a>
                        </div>
                    </div>

                    <div className="profile-info">
                        <div className="profile-info-item">
                            {profile.postsCount} публикаций
                        </div>
                        <div className="profile-info-item">
                            {profile.followingCount} подписок
                        </div>
                        <div className="profile-info-item">
                            {profile.followersCount} подписчиков
                        </div>
                    </div>

                    <div className="pet-name-info">
                        <div>
                            {profile.petName}
                        </div>
                    </div>
                    <div className="info-bio">
                        <div>
                            {profile.infoBio}
                        </div>
                    </div>

                </div>
            </div>
        </div>
    );
};
export default MyProfileInfo;