   M S B A M L   `   `   `  ����H  DFasetto.World, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Fasetto.WorldFasetto.World  5      M IFasetto.World.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:Fasetto.World.Core;assembly=Fasetto.World.CoreFasetto.World.Core 5      .    (Fasetto.World.ChatMessageListItemControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Fasetto.World     5      Mcore<clr-namespace:Fasetto.World.Core;assembly=Fasetto.World.Core     5      .��5
      ��   �� Padding$  5q�6   ._�5   
   � .+�5      �� $	��Top=�6   $
��Left=�5      $��0 7.5 0 7.5q�5      $��35��5      
��� � �   ForegroundLightBrush#��[  5      $��1q�5       �� CornerRadius 5      �� *ActualWidth+ �� RelativeSource �� *Self+��5      �� *ActualWidth+ �� *Self+y�5      �� *
SentByMe+ �� 	Converter 0   *Fasetto.World.BooleanToVisibilityConverter  ._�5      �� $��Center=�5      $��Center=�5        LatoRegular#��[ 5        FontSizeRegular#��[ 5      ��5      �� *
Initials+5      5!      � 5$      $��	25 0 25 0q�6   ��5%      �� *
SentByMe+ 0   *Fasetto.World.SentByMeToAlignmentConverter   � Triggers 5'      :� 5)       :� RoutedEvent$ 
MouseEnter��6#   .[�5*      �� .��5+      ��  �� 
TargetName$ ExtraDetails��6)    �� TargetProperty$ Opacity�6N   .��5,   "   W� 	 W� To$ 1X�62   	 g� Duration$	 
00:00:00.5D�69   5-      5.      5/      :� 51      $ 
MouseLeave��6#   .[�52      �� .��53      �� $ ExtraDetails��6)   $ Opacity�6N   .��54   "   W� $ 0X�62   $	 
00:00:00.5D�69   55      56      57      
 � RowDefinitions
 5;      �� 5<      $
��Auto �6$   �� 5=      $
��Auto �6$   .+�5A      �� $	��Top=�5B      ��5A      �� *
SentByMe+   ._�5D      ��   SpinningText#��[ 6    #��[  5E   !    �� Padding$ 20q�5F   !    � DataContext 5G   !   �� *ImageAttachment+y�5H   !   �� *ImageLoaded+ 4   .Fasetto.World.BooleanToVisibilityGoneConverter   �� ConverterParameter$
 True�� �� FallbackValue$ 	Collapsed��5J      �� 5M      $ 10��6   $��0 0 0 5q�5N      $
��Left=�5O      $	��600��5P      ._�5S      �� �   �Fasetto.World.BaseAttachedProperty`2[[Fasetto.World.FadeInImageOnLoadProperty, Fasetto.World, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value . �   �Fasetto.World.BaseAttachedProperty`2[[Fasetto.World.ClipFromBorderProperty, Fasetto.World, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value .  6   �� *ImageAttachment+��5T      �� *LocalFilePath+ �� NotifyOnTargetUpdated . 5V      5Y      � 5\      $��1��6   $��2��5^   n   ��5]      �� *
SentByMe+   y�5^      �� *
HasMessage+   
 5a      �� 5b      $
��Auto �6(   �� 5c      $
��Auto �6(   �� 5d      $
��Auto �6(   .+�5h      �� $ 10��6   $  15q�5j      ��5i      �� *
SentByMe+ 1   +Fasetto.World.SentByMeToBackgroundConverter  ._�5m      �� $��Center=�6$     WordDarkBlueBrush#��[ 5n   !   #��[ 5o   !   $
��Wrap=�5p   !   ��5q   !   �� *	Message+5t      F� 5w      
���   �"����        р�� ��� � -1    	$��2��5y      $��
15 -1 15 0q�5z       K� ZIndex$ 1��5{      $��0��5}      ��5|      �� *
SentByMe+   ��5~      �� *
SentByMe+   �� 5�      -   5        $��ExtraDetails��5�   !   $��2��65    �� Orientation$ 
Horizontal=�5�       J� Opacity$ 0Q�5�      ��5�      �� *
SentByMe+   $
 true��.+�5�      �� $��Center=�6%   #��[  5�      #��[ 5�        FontSizeSmall#��[ 5�      $
��Wrap=�5�      $��0 0 15 0q�5�      ��5�      �� *MessageSentTime+ .   (Fasetto.World.TimeToDisplayTimeConverter  5�      �� 5�      $��Center=�6%   #��[ 5�      #��[ 5�      #��[ 5�      $
��Wrap=�5�      ��5�      �� *MessageReadTime+ +   %Fasetto.World.TimeToReadTimeConverter  5�      5�      5�      5�      5�      5�      5�      