using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazRTC.Services;

internal interface IDataCannel
{
    ///Properties
    //binaryType
    //bufferedAmount
    //bufferedAmountLowThreshold
    //id
    //label
    //maxPacketLifeTime
    //maxRetransmits
    //negotiated
    //ordered
    //protocol
    //readyState

    ///Methods
    //close()
    //send()

    ///Events
    //bufferedamountlow
    //close
    //closing
    //error
    //message
    //open

}
