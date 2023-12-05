import React from 'react'

const CreateQuestion = () => {
    return (
        <div class="row">
            <div class="col-md-4">
                <form>
                    <div class="form-group">
                        <label class="control-label">Question Text</label>
                        <textarea class="form-control" />
                    </div>
                    <div class="form-group">
                        <label class="control-label">Answer Text</label>
                        <textarea class="form-control" />
                    </div>
                    <div class="form-group">
                        <input type="submit" value="Create" class="btn btn-primary" />
                    </div>
                </form>
            </div>
        </div>
    )
}

export default CreateQuestion
