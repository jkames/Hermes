namespace Mapbox.Examples
{
    using Mapbox.Unity.Location;
    using Mapbox.Utils;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class LocationToInput : MonoBehaviour
    {

        [SerializeField]
        InputField _statusText;
        [SerializeField]
        RectTransform info;
        [SerializeField]
        RectTransform target;

		private AbstractLocationProvider _locationProvider = null;
		void Start()
		{
			if (null == _locationProvider)
			{
				_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider as AbstractLocationProvider;
			}
		}


		void Update()
		{
            target.sizeDelta = new Vector2(info.rect.width - 20, target.sizeDelta.y);

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
						this.enabled=false;
					}
				}
			}

		}
	}
}
