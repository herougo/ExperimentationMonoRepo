import React from 'react';

const QuestionDisplay = (props) => {
    const { selectedQuestion } = props
    const backgroundColour = selectedQuestion.done ?
        "bg-secondary" :
        "bg-primary"
    const classes = backgroundColour + " text-white p-3 rounded"

    return (
        <div className={classes}>
            {
                selectedQuestion.done ?
                    <div className="rounded p-1 text-center bg-success">Done</div> :
                    null
            }
            <div>
                <label>Question Text</label>
                <textarea readonly className="w-100">{selectedQuestion.questionText}</textarea>
            </div>
            <div>
                <label>Answer Text</label>
                <textarea readonly className="w-100">{selectedQuestion.answerText}</textarea>
            </div>
            <div>
                <label>Courses</label>
                <textarea readonly className="w-100">{selectedQuestion.course}</textarea>
            </div>
            <div>
                <label>Tags</label>
                <textarea readonly className="w-100">{selectedQuestion.tags}</textarea>
            </div>
        </div>
    )
}

export default QuestionDisplay