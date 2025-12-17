import axios from 'axios';
import React, { useEffect, useState } from 'react'
import Select from "react-select";

const ProductFilter = ({ handleFetchProduct }) => {
    const [options, setOptions] = useState([]);
    const [selectedItem, setSelectedItem] = useState({ value: 0, label: "Chọn tất cả" });
    const [search, setSearch] = useState("");

    const fetchData = async () => {
        try {
            const res = await axios.get("https://localhost:44382/api/Category/GetCategories");
            const data = res.data.map(item => ({
                value: item.id,
                label: item.name,
            }));
            setOptions([{ value: 0, label: "Chọn tất cả" }, ...data]);

        } catch (error) {
            console.error("Error fetching categories:", error);
        }
    };

    useEffect(() => {
        fetchData();
    }, []);

    return (
        <div className="flex items-center gap-3 w-full">
            <div className="w-1/3">
                <Select
                    options={options}
                    value={selectedItem}
                    onChange={setSelectedItem}
                    isClearable={false}
                    classNamePrefix="react-select"
                    styles={{
                        control: (provided) => ({
                            ...provided,
                            minHeight: '44px',
                            width: '100%',
                        }),
                    }}
                />
            </div>

            <input
                type="text"
                placeholder="Nhập từ khóa..."
                value={search}
                onChange={e => setSearch(e.target.value)}
                className="flex-1 px-3 py-2 rounded-lg border border-gray-300 focus:outline-none focus:ring-2 focus:ring-blue-500"
            />

            <button
                onClick={() => handleFetchProduct(selectedItem.value, search)}
                type="button"
                className="text-white bg-blue-600 hover:bg-blue-700 focus:ring-4 focus:ring-blue-300 shadow-sm font-medium rounded-md text-sm px-4 py-2.5 focus:outline-none">
                Tìm kiếm
            </button>
        </div>
    );
}

export default ProductFilter