import React from 'react'

const Create = (props) => {
    return (
        <>
            <h1>Create</h1>
            <h4>Question</h4>
            <hr />
            <div class="row">
                <div class="col-md-4">
                    <form>
                        <div class="text-danger"></div>
                        <div class="form-group">
                            <label class="control-label">Question Text</label>
                            <input class="form-control" />
                            <span class="text-danger"></span>
                        </div>
                        <div class="form-group">
                            <label class="control-label">Answer Text</label>
                            <input class="form-control" />
                            <span class="text-danger"></span>
                        </div>
                        <div class="form-group">
                            <input type="submit" value="Create" class="btn btn-primary" />
                        </div>
                    </form>
                </div>
            </div>
        </>
    )
}

export default Create
