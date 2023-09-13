import React from 'react';
import ReactApexChart from "react-apexcharts";

class Objective extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            apartments: [],
            medians: [],
            filterValues: [],
            options: {
                chart: {
                    id: 'apexchart-example',
                    height: 350,
                    type: 'line'
                },
                xaxis: {
                    categories: []
                }
            },
            series: [{
                name: '',
                data: []
            }]
        };
    }

    componentDidMount() {
        this.refreshInfo();
    }

    refreshInfo(roomCount) {
        fetch("http://localhost:5150/" +
            (roomCount ? "?roomcount=" + roomCount : ""))
            .then((res) => res.json())
            .then(
                (result) => {
                    this.setState({
                        apartments: result
                    });
                }
            );
        fetch("http://localhost:5150/filtrValues")
            .then((res) => res.json())
            .then(
                (result) => {
                    this.setState({
                        filterValues: result
                    });
                }
            );
        fetch("http://localhost:5150/medians" +
            (roomCount ? "?roomcount=" + roomCount : ""))
            .then(response => response.json())
            .then(
                (result) => {
                    this.setState({
                        options: {
                            ...this.state.options,
                            xaxis: {
                                ...this.state.options.xaxis,
                                categories: result.map(x => x.date)
                            }
                        },
                        series:
                            [{
                                ...this.state.series,
                                data: result.map(x => x.price)
                            }]

                    })


                }
            );

    }

    render() {
        const {apartments} = this.state;

        return <div>
            Фильтра по колличеству комнат:
            <select onChange={e => this.setRoomCount(e.target.value)}>
                <option></option>
                {this.state.filterValues.map(x =>
                    <option value={x}>{x}</option>
                )}
            </select>
            <br/>
            <br/>
            <br/>
            <div>
                Квартиры:
                {

                    apartments?.map(x =>
                        <div>
                            <div>Количество комнат: {x.room}</div>
                            <div>Ссылка на сайт с описанием: {x.link}</div>
                            <div>Цена: {x.price}</div>
                        </div>
                    )
                }
            </div>

            <ReactApexChart options={this.state.options} series={this.state.series} type="line" height={350}/>
        </div>;
    }

    setRoomCount(value) {
        console.log(value)

        this.refreshInfo(value);
    }
}

export default Objective;