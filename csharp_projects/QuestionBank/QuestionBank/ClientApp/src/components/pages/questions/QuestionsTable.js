import React, { useCallback } from 'react';

const QuestionsTable = (props) => {
    const { questions, setSelectedQuestion } = props

    return (
        <table className="table">
            <thead>
                <tr>
                    <th>Question</th>
                    <th>Done</th>
                    <th>Course</th>
                    <th>Tags</th>
                </tr>
            </thead>
            <tbody>
                {questions.map((question, ix) =>
                    <tr key={question.id} onClick={e => setSelectedQuestion(questions[ix])}>
                        <td>{question.questionText}</td>
                        <td><input type="checkbox" readOnly defaultChecked={question.done}></input></td>
                        <td>{question.course}</td>
                        <td>{question.tags}</td>
                    </tr>
                )}
            </tbody>
        </table>
    );
}

export default QuestionsTable