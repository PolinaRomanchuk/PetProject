import './comment.css'

function Comment(comment) {

    return (
        <>
            <div className="comment-container">
                <img className="avatar-comment" src="https://icons.veryicon.com/png/o/internet--web/prejudice/user-128.png" alt="фото комментатора" />
                <div className="name-comment"> имя </div>
                <div className="comment-text">
                    {comment.comment.commentText}
                </div>
                <div className="comment-info">00:38 07.07.2024 Нравится: 0</div>
            </div>
        </>
    );
};

export default Comment;