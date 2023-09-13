import React from 'react';
import ReactApexChart from "react-apexcharts";

class Objective extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            apartments: [],
            medians: [],
            options: {
                chart: {
                    id: 'apexchart-example',
                    height: 350,
                    type: 'line'
                },
                xaxis: {
                    categories: [1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999]
                }
            },
            series: [{
                name: 'series-1',
                data: [30, 40, 35, 50, 49, 60, 70, 91, 125]
            }]
        };
    }

    componentDidMount() {
        fetch("http://localhost:5150/")
            .then((res) => res.json())
            .then(
                (result) => {
                    this.setState({
                        apartments: result
                    });
                }
            );
        fetch("http://localhost:5150/medians")
            .then(response => response.json())
            .then(
                (result) => {
                    this.setState({
                        medians: result
                    });

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
        const {apartments, medians} = this.state;
        return <div>
            <div>
                {

                    apartments?.map(x =>
                        <div>
                            <div>{x.room}</div>
                            <div>{x.link}</div>
                            <div>{x.price}</div>
                        </div>
                    )
                }
            </div>
            <div>
                {

                    medians?.map(x =>
                        <div>
                            <div>{x.price}</div>
                            <div>{x.date}</div>
                        </div>
                    )
                }
            </div>

            <ReactApexChart options={this.state.options} series={this.state.series} type="line" height={350}/>
        </div>;
    }
}

export default Objective;