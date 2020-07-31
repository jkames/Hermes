namespace Mapbox.Examples
{
    using Mapbox.Unity.Location;
    using Mapbox.Utils;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class CordToWeather : MonoBehaviour
    {

        [SerializeField]
        Text _statusText;

        string[] cords;
        bool sent;

        private AbstractLocationProvider _locationProvider = null;
        void Start()
        {
            if (null == _locationProvider)
            {
                _locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider as AbstractLocationProvider;
                cords[0] = null;
                cords[1] = null;
                sent = false;
            }
        }


        void Update()
        {
            Location currLoc = _locationProvider.CurrentLocation;

            if (currLoc.IsLocationServiceInitializing)
            {
                _statusText.text = "location services are initializing";
            }
            else
            {
                if (!currLoc.IsLocationServiceEnabled)
                {
                    _statusText.text = "location services not enabled";
                }
                else
                {
                    if (currLoc.LatitudeLongitude.Equals(Vector2d.zero))
                    {
                        _statusText.text = "Waiting for location ....";
                    }
                    else
                    {
                        _statusText.text = string.Format("{0}", currLoc.LatitudeLongitude);
                        if (sent == false)
                        {
                            cords = _statusText.text.Split(',');
                            sent = true;
                        }
                        
                    }
                }
            }

        }

        string getLat()
        {
            return cords[0];
        }

        string getLong()
        {
            return cords[1];
        }

    }
}