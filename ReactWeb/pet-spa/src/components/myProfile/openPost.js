import React, { useContext, useState } from "react";
import { AuthContext } from '../login/auth';
import './openPost.css';
import Comment from "./Comment";
import { ArrowLeft, ArrowRight } from 'lucide-react';
import { addNewCommentApi } from '../../services/addNewCommentApi.js'


function OpenPost({ model, setActive, userPhoto, fullmodel, active, nextPost, prevPost, }) {
    const { userId, name } = useContext(AuthContext);
    const [commentText, setCommentText] = useState('');
    const { AddNewComment } = addNewCommentApi;

    const closeWindow = () => {
        setActive(false);
    }
    const handleSubmit = () => {
        // AddNewComment(commentText, userId, model);

        const formData = new FormData();
        formData.append('commentText', commentText);
        formData.append('commentAuthor', userId);
        formData.append('currentPost', model.id);
        AddNewComment(formData);
    };

    return (
        <div className="open-post-main-container">
            <button className="btn-paginator-arrow left" onClick={prevPost}> <ArrowLeft /></button>
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
                            {
                                model.comments?.map(comment => {
                                    return (<Comment comment={comment}></Comment>)
                                })
                            }
                        </div>
                        <div className="add-new-comment-place">
                            <form>
                                <textarea
                                    className="new-comment"
                                    type="text"
                                    placeholder="оставьте комментарий"
                                    value={commentText} onChange={e => setCommentText(e.target.value)} />
                            </form>
                            <button type="submit" onClick={handleSubmit} >отправить</button>
                        </div>
                    </div>
                </div>
            </div>
            <button className="btn-paginator-arrow right" onClick={nextPost}><ArrowRight /></button>
        </div>
    );
};

export default OpenPost;