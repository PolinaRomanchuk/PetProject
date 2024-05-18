import '../myProfile/profile.css'
import { profileApi } from '../../services/myProfileApi'
import { useState, useEffect } from 'react';
import { AuthContext } from '../login/auth';
import { useContext } from 'react';
import Post from './Post';
import { Pencil, Plus  } from 'lucide-react';

function Profile() {
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
        <>
            <div className='content-container'>
                <div className="header-profile-container">
                    <div className="avatar">
                        <img className="avatar" src={profile.photoUrl} />
                    </div>
                    <div className="header-profile-main-info">
                        <div className="name-info">
                            {name}
                            <div>
                                <button className='edit-profile-button'>
                                 <Pencil className="pencil-logo"/>
                                  
                                </button>
                            </div>
                            <div>
                                {<button className='add-new-post-button' >
                                    <Plus className="plus-logo"/>
                                </button>}
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
                <div className='posts-list-container'>
                    {
                        profile.posts?.map(post => {
                            return (<Post model={post}></Post>)
                        })
                    }
                </div>
            </div>
        </>
    );
};
export default Profile;