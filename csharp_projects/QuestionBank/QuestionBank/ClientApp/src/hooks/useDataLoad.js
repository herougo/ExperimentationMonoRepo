import React, { useState, useCallback, useEffect } from 'react'

const useDataLoad = (asyncDataFetchFunction, defaultData=null) => {
    const [data, setData] = useState(defaultData)

    const onChange = useCallback(() => {
        setData(defaultData)
        asyncDataFetchFunction((d) => setData(d))
    })

    useEffect(onChange, [])

    return [data, onChange]
}

export default useDataLoad