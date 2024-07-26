import React, { useContext, useState } from "react";
import { AuthContext } from '../login/auth';
import './openPost.css';
import Comment from "./Comment";

function OpenPost({ model, setActive, userPhoto, fullmodel }) {
    const { userId, name } = useContext(AuthContext);
    const closeWindow = () => {
        setActive(false);
    }

    return (
        <>
            <div className="open-post-container">
                <button className="close-button" onClick={closeWindow} />
                <div className="selected-photo-container">
                    <div className="selected-photo">
                        <img src={model.imageUrl} alt="фото поста" />
                    </div>
                    <div className="post-info-container">
                        <div className="post-info">
                            <img className="avatar-profile" src={userPhoto} alt="фото профиля" />
                            <div className="name-profile"> {name} </div>
                        </div>
                        <div className="desc-post">
                            {model.description}
                        </div>
                        <div className="date-post">{model.dateOfPublication} </div>
                        <div className="likes-number"> Нравится: {model.countOfLikes}</div>
                        <div className="comment-post">
                            <Comment></Comment>
                            <Comment></Comment>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
};

export default OpenPost;