import '../myProfile/profile.css'
import Modal from '../modal/modal';
import { useState, useEffect } from 'react';
import OpenPost from './openPost';

function Post({ model, userPhoto, fullmodel }) {
    const [active, setActive] = useState(false);
    const [currentIndex, setCurrentIndex] = useState(fullmodel.indexOf(model));

    const prevPost = () => {
        setCurrentIndex((prevIndex) => (prevIndex + 1) % fullmodel.length);
    };

    const nextPost = () => {
        setCurrentIndex((prevIndex) => (prevIndex - 1 + fullmodel.length) % fullmodel.length);
    };

    return (
        <>
            <div className="post-item" >
                <img src={model.imageUrl} onClick={() => setActive(true)} />
            </div>
            <Modal active={active} setActive={setActive}>
                <OpenPost
                    active={active}
                    setActive={setActive}
                    model={fullmodel[currentIndex]}
                    userPhoto={userPhoto}
                    fullmodel={fullmodel}
                    nextPost={nextPost}
                    prevPost={prevPost} />
            </Modal>
        </>
    );
};

export default Post;
