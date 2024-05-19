import { useState, useEffect, useContext } from "react";
import { useNavigate } from 'react-router-dom';
import { AuthContext } from '../login/auth';
import UpdateProfileApi from '../../services/updateProfileApi.js'
import '../updateProfile/update.css'

function UpdateProfile() {
    const [userName, setUserName] = useState('');
    const [petName, setPetName] = useState('');
    const [petInfo, setPetInfo] = useState('');
    const [photoProfile, setPhotoProfile] = useState('');
    const { userId } = useContext(AuthContext);
    const navigate = useNavigate();

    const SubmitHandler = (e) => {
        e.preventDefault();
        UpdateProfileApi( petName, petInfo, userId)
        navigate('/profile');
    };

    return (
        <>
            <div className="container-edit">
                <h3>Редактировать профиль</h3>
                <form onSubmit={SubmitHandler} >
                    <input type="text" placeholder="имя питомца" value={petName} onChange={e => setPetName(e.target.value)} />
                    <input type="text" placeholder="описание" value={petInfo} onChange={e => setPetInfo(e.target.value)} />
                    <button>Обновить информацию</button>
                </form>
            </div>
        </>
    )
}

export default UpdateProfile;