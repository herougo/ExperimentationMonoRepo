import React, { useState, useCallback, useEffect } from 'react'

const useDataLoad = (asyncDataFetchFunction) => {
    const [data, setData] = useState(null)

    const onChange = useCallback(() => {
        setData(null)
        asyncDataFetchFunction((d) => setData(d))
    })

    useEffect(onChange, [])

    return [data, onChange]
}

export default useDataLoad