import '../myProfile/profile.css'
import { profileApi } from '../../services/myProfileApi'
import { useState, useEffect } from 'react';
import { AuthContext } from '../login/auth';
import { useContext } from 'react';
import Post from './Post';
import { Pencil, Plus } from 'lucide-react';
import { useNavigate } from 'react-router-dom';

function Profile() {
    const [profile, setProfile] = useState('');
    const { GetUserProfile } = profileApi;
    const { userId, name } = useContext(AuthContext);
    const navigate = useNavigate();

    useEffect(function () {
        GetUserProfile(userId)
            .then(response => {
                console.log(response.data)
                setProfile(response.data)
            });
    }, [])

    function Redirect(){
        navigate('/edit');
    }

    return (
        <>
            <div className='content-container'>
                <div className="header-profile-container">
                    <div className="avatar">
                        <img className="avatar" src={profile.photoUrl} alt='Фото профиля' />
                    </div>
                    <div className="header-profile-main-info">
                        <div className="name-info">
                            {name}
                            <button className='edit-profile-button'>
                                <Pencil className="pencil-logo" onClick={Redirect} />
                            </button>
                            {<button className='add-new-post-button' >
                                <Plus className="plus-logo" />
                            </button>}
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
                            {profile.petName}
                        </div>
                        <div className="info-bio">
                            {profile.infoBio}
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