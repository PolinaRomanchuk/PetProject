import React, { useContext, useState } from "react";
import './newPost.css';
import { AuthContext } from '../login/auth';
import { addNewPostApi } from '../../services/addNewPostApi.js'

function NewPost({ model, setActive }) {
    const [selectedFile, setSelectedFile] = useState(null);
    const [description, setDescription] = useState('');
    const [preview, setPreview] = useState(null);
    const [dragActive, setDragActive] = useState(false);
    const [confirmedFile, setConfirmedFile] = useState(false);
    const [completedForm, setCompletedForm] = useState(false);
    const { userId, name } = useContext(AuthContext);
    const { AddNewPost } = addNewPostApi;

    const handleChange = (e) => {
        e.preventDefault();
        if (e.target.files && e.target.files[0]) {
            setPreview(URL.createObjectURL(e.target.files[0]));
            setSelectedFile(e.target.files[0]);
        }
    };

    const handleReset = () => {
        setSelectedFile(null);
        setPreview(null);
        setConfirmedFile(false);
    };

    const handleConfirm = () => {
        setConfirmedFile(true);
    };

    const handleSubmit = () => {
        console.log(selectedFile);
        const formData = new FormData();
        formData.append('file', selectedFile);
        formData.append('id', userId);
        formData.append('description', description)
        AddNewPost(formData);
        handleReset();
        setCompletedForm(true);
    };

    const handleDrag = (e) => {
        e.preventDefault();
        setDragActive(true);
    };

    const handleLeave = (e) => {
        e.preventDefault();
        setDragActive(false);
    };

    const handleDrop = (e) => {
        e.preventDefault();
        setDragActive(false);
        if (e.dataTransfer.files && e.dataTransfer.files[0]) {
            setPreview(URL.createObjectURL(e.dataTransfer.files[0]));
            setSelectedFile(e.dataTransfer.files[0]);
        }
    };

    const closeWindow = () => {
        handleReset();
        setActive(false);
    }

    return (
        <>
            <div className="wrapper">
                <button className="close-button" onClick={closeWindow} />
                <div className="header-form-new-post">Создание новой публикации</div>
                <div className={` ${completedForm ? "invisible" : ""}`}>
                    <form
                        className={`form-new-post ${dragActive ? "drag" : ""} ${selectedFile ? "invisible" : ""}`}
                        onReset={handleReset}
                        onSubmit={handleSubmit}
                        onDragEnter={handleDrag}
                        onDragOver={handleDrag}
                        onDragLeave={handleLeave}
                        onDrop={handleDrop}
                    >
                        <div className="help-text">Перетащите фото сюда</div>
                        <p className="help-text">или</p>
                        <label className="onload-new-post">
                            <span>Загрузите фото</span>
                            <input
                                className="invisible"
                                type="file"
                                multiple={false}
                                onChange={handleChange}
                            />
                        </label>
                    </form>

                    {selectedFile && (
                        <div className="selectedFile-container">
                            <div className="new-post-image">
                                <img src={preview} alt="фото профиля" />
                            </div>
                            <button className={`button-submit-post ${confirmedFile ? "invisible" : ""}`} type="submit" onClick={handleConfirm} >
                                Далее
                            </button>
                            <button className={`button-submit-post ${confirmedFile ? "" : "invisible"}`} type="submit" onClick={handleSubmit}>
                                Опубликовать
                            </button>
                            <button className="button-reset-post" type="submit" onClick={handleReset}>
                                Изменить
                            </button>

                            <div className={`${confirmedFile ? "" : "invisible"}`}>
                                <form>
                                    <div className="info-profile">
                                        <img className="new-post-avatar" src={model} alt="фото профиля" />
                                        {name}
                                    </div>

                                    <textarea
                                        className="new-post-description"
                                        type="text"
                                        placeholder="чем вы хотите поделиться"
                                        value={description} onChange={e => setDescription(e.target.value)} />
                                </form>
                            </div>
                        </div>
                    )}
                </div>
                <div className={`successfully-created-photo ${completedForm ? "" : "invisible"}`}>Ваше фото успешно добавлено, обновите страницу</div>
            </div>
        </>
    );
};

export default NewPost;
