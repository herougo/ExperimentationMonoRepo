import React, { useState } from 'react';
import QuestionsTable from './QuestionsTable';
import { getFilteredQuestions } from '../../../utils/apiInteraction'
import useDataLoad from '../../../hooks/useDataLoad';
import QuestionDisplay from './QuestionDisplay';

const QuestionsPage = () => {
    const [tableData, onChange] = useDataLoad(getFilteredQuestions)
    const [selectedQuestionId, setSelectedQuestionId] = useState(null)
    let selectedQuestionIx = null
    if (tableData !== null) {
        for (var i = 0; i < tableData.length; i++) {
            if (selectedQuestionId === tableData[i].id) {
                selectedQuestionIx = i
                break
            }
        }
    }


    const contents = tableData === null ?
        "Loading..." :
        <QuestionsTable questions={tableData} setSelectedQuestionId={setSelectedQuestionId} />

    const questionDisplay = selectedQuestionIx === null ?
        null :
        <div class="col">
            <QuestionDisplay
                questions={tableData}
                selectedQuestionIx={selectedQuestionIx}
                onQuestionDataChange={onChange}
            />
        </div>

    return (
        <div>
            <h1>Questions</h1>
            <button class="btn btn-primary m-1">Generate Sample Exam</button><br/>
            <button class="btn btn-primary m-1">Export Questions to PDF</button><br />
            <div class="row">
                <div class="col">
                    {contents}
                </div>
                {questionDisplay}
            </div>
        </div>
    );
}

export default QuestionsPage