import { useState, useEffect, useContext, useRef } from "react";
import { useNavigate, useParams } from 'react-router-dom';
import { AuthContext } from '../login/auth';
import { updateProfileApi } from '../../services/updateProfileApi.js'
import '../updateProfile/update.css'
import { profileApi } from '../../services/myProfileApi'

function UpdateProfile() {
    const filePicker = useRef(null);
    const [profile, setProfile] = useState('');
    const [selectedFile, setSelectedFile] = useState(null);
    const [petName, setPetName] = useState('');
    const [petInfo, setPetInfo] = useState('');
    const { userId, name } = useContext(AuthContext);
    const navigate = useNavigate();
    const params = useParams();
    console.log(params);
    const { GetUserProfile } = profileApi;
    const { UpdateProfileApi, UpdateAvatarApi } = updateProfileApi;


    useEffect(function () {
        GetUserProfile(userId)
            .then(response => {
                console.log(response.data)
                setProfile(response.data)
            });
    }, [profile.photoUrl])

    const SubmitHandler = (e) => {
        e.preventDefault();
        UpdateProfileApi(petName, petInfo, userId)
        navigate('/profile');
    };

    const uploadhandle = async (e) => {
        const formData = new FormData();
        formData.append('file', selectedFile);
        formData.append('id', userId);
        UpdateAvatarApi(formData);
    }

    const handleChange = (e) => {
        setSelectedFile(e.target.files[0]);
        const formData = new FormData();
        formData.append('file', selectedFile);
        formData.append('id', userId);
        UpdateAvatarApi(formData);
    };

    const handlePick = (e) => {
        filePicker.current.click();
    }

    return (
        <>
            <div className="container-edit">
                <div className="header-edit">Редактировать профиль</div>

                <div className="content-edit">
                    <div className="avatar-container">
                        <img className="avatar-edit" src={profile.photoUrl} />
                    </div>

                    <div className="column-container">
                        <div className="update-photo-container">
                            <div className="login-name">{name}</div>
                            <button className="update-photo-button" onClick={handlePick}>Сменить фото профиля</button>
                            <input
                                type="file"
                                ref={filePicker}
                                name="file"
                                className="hidden"
                                accept="image/*, .png, .jpg"
                                onChange={handleChange}
                            />
                        </div>
                        <form className="form-edit" onSubmit={SubmitHandler} >
                            <div className="edit-item"><span className="name-edit-line petName">Имя питомца</span>
                                <input type="text" placeholder={profile.petName} value={petName} onChange={e => setPetName(e.target.value)} />
                            </div>
                            <div className="edit-item"><span className="name-edit-line petInfo">Описание</span>
                                <input type="text" placeholder={profile.petInfo} value={petInfo} onChange={e => setPetInfo(e.target.value)} />
                            </div>
                            <button className="update-button">Обновить информацию</button>
                        </form>
                    </div>
                </div>
            </div>
        </>
    )
}

export default UpdateProfile;