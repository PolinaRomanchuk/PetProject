import '../myProfile/profile.css'

function Post({ model }) {

    return (
        <>
            <div className="post-item">
                <img src={model} />
            </div>
        </>
    );
};

export default Post;
