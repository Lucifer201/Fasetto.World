   M S B A M L   `   `   `  ����H  DFasetto.World, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Fasetto.WorldFasetto.World  5      M IFasetto.World.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:Fasetto.World.Core;assembly=Fasetto.World.CoreFasetto.World.Core 5           Fasetto.World.VerticalMenu   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Fasetto.World     5      Mcore<clr-namespace:Fasetto.World.Core;assembly=Fasetto.World.Core     5      .��5
      �� 
���������5      �� *Items+��5   
   �� 5      .R�5      � .+�5      � y�6   �� *Type+  �� 	Converter  5   /Fasetto.World.MenuItemTypeToVisibilityConverter   �� ConverterParameter$ Header��.+�5      �� $	��0.5��6!      ForegroundDarkBrush#��[  6.   �� 5        LatoRegular#��[ 5   $     FontSizeSmall#��[ 5   $    �� Padding$ 0 5 10 5q�5   $     ForegroundLightBrush#��[ 5   $   $
��Left=�5   $   #��[  5    $   ��5   $   �� *Text+5    $   5#      �� 5&      #��[ 6    �� CornerRadius$ 8��5'       �� Padding$ 8q�5(      y�5)      �� *Type+    $ TextAndIcon�� � Triggers 5+      :� 5,       :� RoutedEvent$ 
MouseEnter��6+   .[�5-   "   �� .��5.   &   �� .��5/   *   ��   WordBlue	 �� To# [ 69    g� Duration$ 	00:00:0.2D�50   9   	 �� TargetProperty$	 Background.Color�51   9   �� 52   *     ForegroundLight# [ 69   $ 	00:00:0.2D�53   9   $	 Foreground.Color�54   9   
 �� 
TargetName$

 icon��55   9   �� 57   *   # [ 69   $ 	00:00:0.2D�58   9   $	 Foreground.Color�59   9   $

 text��5:   9   5<   '   5=   #   5>      :� 5?      $ 
MouseLeave��6+   .[�5@   "   �� .��5A   &   �� .��5B   *   �� # [ 69   $ 	00:00:0.2D�5C   9   $	 Background.Color�5D   9   �� 5E   *     ForegroundVeryDark# [ 69   $ 	00:00:0.2D�5F   9   $	 Foreground.Color�5G   9   $

 icon��5H   9   �� 5J   *   # [ 69   $ 	00:00:0.2D�5K   9   $	 Foreground.Color�5L   9   $

 text��5M   9   5O   '   5P   #   5Q      ._�5T      �  � ColumnDefinitions 5U      �� 5V   "   $
��Auto �63   �� 5W   "   $��* �63   .+�5[      �� $
��icon��6(   $ 5q�5\   (     FontAwesome#��[ 5]   (     ForegroundVeryDarkBrush#��[ 5_   (   ��5^   (   �� *Icon+  2   ,Fasetto.World.IconTypeToFontAwesomeConverter  5_   (   �� 5b      $
��text��6(   $��1��5c   (   $��Center=�5d   (   $��5 0 5 0q�5e   (   #��[ 5g   (   #��[ 5h   (   ��5f   (   �� *Text+5h   (   5j      5k      5m      5n      5q      5r      