import React, { useCallback } from 'react';

const QuestionsTable = (props) => {
    const { questions, setSelectedQuestionId } = props

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
                {questions.map((question) =>
                    <tr key={question.id} onClick={e => setSelectedQuestionId(question.id)}>
                        <td>{question.questionText}</td>
                        <td><input type="checkbox" disabled defaultChecked={question.done}></input></td>
                        <td>{question.course}</td>
                        <td>{question.tags}</td>
                    </tr>
                )}
            </tbody>
        </table>
    );
}

export default QuestionsTable